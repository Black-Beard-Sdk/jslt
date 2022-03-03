using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Bb.Intellisense;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Bb.Parsers.Intellisense
{

    public class IntellisenseVisitor : IParseTreeVisitor<IEnumerable<Index<IParseTree>>>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        public IntellisenseVisitor(Antlr4.Runtime.Parser parser)
        {
            this._parser = parser;
        }

        public List<IntellisenseKey> ResolveIntellisense(IParseTree tree, int position)
        {

            var items = this.Visit(tree).ToList();
            Index<IParseTree>? last = null;

            foreach (var item in items)
                if (position - 1 <= item.StartIndex)
                {
                    last = item;
                    break;
                }

            if (last != null && last.Item != null)
            {

                var keys = EvaluateIntellisense(last.Item);
                return keys;

            }

            return null;

        }

        private List<IntellisenseKey> EvaluateIntellisense(IParseTree item)
        {

            List<IntellisenseKey> result = new List<IntellisenseKey>();

            if (item != null)
            {

                HashSet<int> _h = new HashSet<int>();
                HashSet<ATNState> _h2 = new HashSet<ATNState>();


                int ruleIndex;
                if (item is ParserRuleContext r)
                {

                    ruleIndex = r.RuleIndex;
                    var stateInvoking = this._parser.Atn.states[r.invokingState];
                    ResolveExpectedNext(stateInvoking, ruleIndex, false, _h, _h2);
                    HashSet<Token> _h3 = ResolveExpectedTokens(_h2);

                    HashSet<string> _h4 = new HashSet<string>();
                    foreach (var item1 in _h2)
                    {
                        var name = _parser.RuleNames[item1.ruleIndex];
                        if (_h4.Add(name))
                            result.Add(new IntellisenseKey(item1, name));
                    }

                    foreach (var item2 in _h3)
                        result.Add(new IntellisenseKey(item2));

                }
                else if (item is TerminalNodeImpl t)
                {

                    ruleIndex = t.Symbol.TokenIndex;

                }
                else
                {


                }


            }

            return result;

        }


        private HashSet<Token> ResolveExpectedTokens(HashSet<ATNState> _h2)
        {

            var _h = new HashSet<int>();
            var result = new HashSet<Token>();

            foreach (var state in _h2)
            {

                _h.Clear();

                var h2 = new HashSet<AtomTransition>();
                ResolveExpectedToken(state, state.ruleIndex, _h, h2);
                foreach (var transition in h2)
                {
                    var token = Tokens.Get(transition.token);
                    if (token != null)
                        result.Add(token);
                }

            }

            return result;

        }

        private void ResolveExpectedToken(ATNState state, int ruleIndex, HashSet<int> h, HashSet<AtomTransition> h2)
        {

            var current = _parser.RuleNames[state.ruleIndex];
            h.Add(state.stateNumber);

            foreach (Transition transition in state.TransitionsArray)
            {

                if (transition.TransitionType == TransitionType.ATOM)
                {
                    var atom = (AtomTransition)transition;
                    var token = Tokens.Get(atom.token);
                    if (atom.token != -1)
                        h2.Add(atom);
                    return;
                }

                var target = transition.target;
                if (target != null /*&& target.ruleIndex == ruleIndex*/)
                    if (!h.Contains(target.stateNumber))
                        ResolveExpectedToken(target, ruleIndex, h, h2);

            }
        }

        private void ResolveExpectedNext(ATNState state, int ruleIndex, bool flag, HashSet<int> h, HashSet<ATNState> h2)
        {

            h.Add(state.stateNumber);

            var current = _parser.RuleNames[state.ruleIndex];
            var toFind = _parser.RuleNames[ruleIndex];

            if (state.ruleIndex == ruleIndex)
                flag = true;

            foreach (var item in state.TransitionsArray)
            {

                ATNState target = item.target;
                var toAdd = _parser.RuleNames[target.ruleIndex];

                if (flag && target.ruleIndex != ruleIndex)
                    h2.Add(target);

                if (!h.Contains(target.stateNumber))
                    ResolveExpectedNext(target, ruleIndex, flag, h, h2);

            }

        }


        public IEnumerable<Index<IParseTree>> Visit(IParseTree tree)
        {
            return tree.Accept(this);
        }

        public IEnumerable<Index<IParseTree>> VisitChildren(IRuleNode node)
        {

            if (node is Antlr4.Runtime.ParserRuleContext ctx)
            {

                var startIndex = ctx.Start.StartIndex;
                var stopIndex = ctx.Stop.StopIndex;

                yield return new Index<IParseTree>(startIndex, stopIndex, node);

                for (int i = 0; i < node.ChildCount; i++)
                {
                    var child = node.GetChild(i);
                    foreach (var item in child.Accept(this))
                        yield return item;
                }

            }
            else
            {

            }

        }

        public IEnumerable<Index<IParseTree>> VisitTerminal(ITerminalNode node)
        {

            if (node is TerminalNodeImpl terminal)
            {

                var startIndex = terminal.Symbol.StartIndex;
                var stopIndex = terminal.Symbol.StopIndex;

                yield return new Index<IParseTree>(startIndex, stopIndex, node);

            }

        }

        public IEnumerable<Index<IParseTree>> VisitErrorNode(IErrorNode node)
        {

            if (node is ErrorNodeImpl error)
            {

                var startIndex = error.Payload.StartIndex;
                var stopIndex = error.Payload.StopIndex;

                yield return new Index<IParseTree>(startIndex, stopIndex, node);

            }

        }

        public Antlr4.Runtime.Parser _parser { get; }

    }

}
