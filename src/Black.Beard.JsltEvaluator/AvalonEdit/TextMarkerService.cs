﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

namespace AppJsonEvaluator
{
    /// <summary>
    /// Handles the text markers for a code editor.
    /// </summary>
    public sealed class TextMarkerService : DocumentColorizingTransformer, IBackgroundRenderer, ITextMarkerService, ITextViewConnect
	{
		TextSegmentCollection<TextMarker> markers;
		TextDocument document;

		public TextMarkerService(TextDocument document)
		{
			if (document == null)
				throw new ArgumentNullException("document");
			this.document = document;
			this.markers = new TextSegmentCollection<TextMarker>(document);
		}

		#region ITextMarkerService

		public ITextMarker Create(int startOffset, int length)
		{

			if (markers == null)
				throw new InvalidOperationException("Cannot create a marker when not attached to a document");

			int textLength = document.TextLength;
			
			if (startOffset < 0 || startOffset > textLength)
				throw new ArgumentOutOfRangeException("startOffset", startOffset, "Value must be between 0 and " + textLength);
			
			if (length < 0 || startOffset + length > textLength)
				throw new ArgumentOutOfRangeException("length", length, "length must not be negative and startOffset+length must not be after the end of the document");

			TextMarker m = new TextMarker(this, startOffset, length);
			markers.Add(m);

			// no need to mark segment for redraw: the text marker is invisible until a property is set
			return m;

		}

		public IEnumerable<ITextMarker> GetMarkersAtOffset(int offset)
		{
			if (markers == null)
				return Enumerable.Empty<ITextMarker>();
			else
				return markers.FindSegmentsContaining(offset);
		}

		public IEnumerable<ITextMarker> TextMarkers
		{
			get { return markers ?? Enumerable.Empty<ITextMarker>(); }
		}

		public void RemoveAll(Predicate<ITextMarker> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException("predicate");
			if (markers != null)
			{
				foreach (TextMarker m in markers.ToArray())
				{
					if (predicate(m))
						Remove(m);
				}
			}
		}

		public void Remove(ITextMarker marker)
		{
			if (marker == null)
				throw new ArgumentNullException("marker");
			TextMarker m = marker as TextMarker;
			if (markers != null && markers.Remove(m))
			{
				Redraw(m);
				m.OnDeleted();
			}
		}

		/// <summary>
		/// Redraws the specified text segment.
		/// </summary>
		internal void Redraw(ISegment segment)
		{
			foreach (var view in textViews)
			{
				view.Redraw(segment, DispatcherPriority.Normal);
			}
			if (RedrawRequested != null)
				RedrawRequested(this, EventArgs.Empty);
		}

		public event EventHandler RedrawRequested;

		#endregion

		#region DocumentColorizingTransformer

		protected override void ColorizeLine(DocumentLine line)
		{
			if (markers == null)
				return;
			int lineStart = line.Offset;
			int lineEnd = lineStart + line.Length;
			foreach (TextMarker marker in markers.FindOverlappingSegments(lineStart, line.Length))
			{
				Brush foregroundBrush = null;
				if (marker.ForegroundColor != null)
				{
					foregroundBrush = new SolidColorBrush(marker.ForegroundColor.Value);
					foregroundBrush.Freeze();
				}
				ChangeLinePart(
					Math.Max(marker.StartOffset, lineStart),
					Math.Min(marker.EndOffset, lineEnd),
					element => {
						if (foregroundBrush != null)
						{
							element.TextRunProperties.SetForegroundBrush(foregroundBrush);
						}
						Typeface tf = element.TextRunProperties.Typeface;
						element.TextRunProperties.SetTypeface(new Typeface(
							tf.FontFamily,
							marker.FontStyle ?? tf.Style,
							marker.FontWeight ?? tf.Weight,
							tf.Stretch
						));
					}
				);
			}
		}
		
		#endregion

		#region IBackgroundRenderer

		public KnownLayer Layer
		{
			get
			{
				// draw behind selection
				return KnownLayer.Selection;
			}
		}

		public void Draw(TextView textView, DrawingContext drawingContext)
		{
			if (textView == null)
				throw new ArgumentNullException("textView");
			if (drawingContext == null)
				throw new ArgumentNullException("drawingContext");
			if (markers == null || !textView.VisualLinesValid)
				return;
			var visualLines = textView.VisualLines;
			if (visualLines.Count == 0)
				return;
			int viewStart = visualLines.First().FirstDocumentLine.Offset;
			int viewEnd = visualLines.Last().LastDocumentLine.EndOffset;
			foreach (TextMarker marker in markers.FindOverlappingSegments(viewStart, viewEnd - viewStart))
			{
				if (marker.BackgroundColor != null)
				{
					BackgroundGeometryBuilder geoBuilder = new BackgroundGeometryBuilder();
					geoBuilder.AlignToWholePixels = true;
					geoBuilder.CornerRadius = 3;
					geoBuilder.AddSegment(textView, marker);
					Geometry geometry = geoBuilder.CreateGeometry();
					if (geometry != null)
					{
						Color color = marker.BackgroundColor.Value;
						SolidColorBrush brush = new SolidColorBrush(color);
						brush.Freeze();
						drawingContext.DrawGeometry(brush, null, geometry);
					}
				}
				var underlineMarkerTypes = TextMarkerTypes.SquigglyUnderline | TextMarkerTypes.NormalUnderline | TextMarkerTypes.DottedUnderline;
				if ((marker.MarkerTypes & underlineMarkerTypes) != 0)
				{
					foreach (Rect r in BackgroundGeometryBuilder.GetRectsForSegment(textView, marker))
					{
						Point startPoint = r.BottomLeft;
						Point endPoint = r.BottomRight;

						Brush usedBrush = new SolidColorBrush(marker.MarkerColor);
						usedBrush.Freeze();
						if ((marker.MarkerTypes & TextMarkerTypes.SquigglyUnderline) != 0)
						{
							double offset = 2.5;

							int count = Math.Max((int)((endPoint.X - startPoint.X) / offset) + 1, 4);

							StreamGeometry geometry = new StreamGeometry();

							using (StreamGeometryContext ctx = geometry.Open())
							{
								ctx.BeginFigure(startPoint, false, false);
								ctx.PolyLineTo(CreatePoints(startPoint, endPoint, offset, count).ToArray(), true, false);
							}

							geometry.Freeze();

							Pen usedPen = new Pen(usedBrush, 1);
							usedPen.Freeze();
							drawingContext.DrawGeometry(Brushes.Transparent, usedPen, geometry);
						}
						if ((marker.MarkerTypes & TextMarkerTypes.NormalUnderline) != 0)
						{
							Pen usedPen = new Pen(usedBrush, 1);
							usedPen.Freeze();
							drawingContext.DrawLine(usedPen, startPoint, endPoint);
						}
						if ((marker.MarkerTypes & TextMarkerTypes.DottedUnderline) != 0)
						{
							Pen usedPen = new Pen(usedBrush, 1);
							usedPen.DashStyle = DashStyles.Dot;
							usedPen.Freeze();
							drawingContext.DrawLine(usedPen, startPoint, endPoint);
						}
					}
				}
			}
		}

		IEnumerable<Point> CreatePoints(Point start, Point end, double offset, int count)
		{
			for (int i = 0; i < count; i++)
				yield return new Point(start.X + i * offset, start.Y - ((i + 1) % 2 == 0 ? offset : 0));
		}

		#endregion

		#region ITextViewConnect
		readonly List<TextView> textViews = new List<TextView>();

		void ITextViewConnect.AddToTextView(TextView textView)
		{
			if (textView != null && !textViews.Contains(textView))
			{
				Debug.Assert(textView.Document == document);
				textViews.Add(textView);
			}
		}

		void ITextViewConnect.RemoveFromTextView(TextView textView)
		{
			if (textView != null)
			{
				Debug.Assert(textView.Document == document);
				textViews.Remove(textView);
			}
		}
		#endregion
	
	}
}
