using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wizards.Actions
{

    public class DirectoryObject : ParserObject
    {


        public DirectoryObject(DirectoryInfo dir, DirectoryObject parent)
            : base(dir.Name)
        {

            _toExclude = new HashSet<string>()
            {
                "bin", "obj", ".git" , "AssemblyInfo.cs", "App.xaml.cs", "Properties"
            }
            ;

            this._parent = parent;
            this._dir = dir;

            this.Subs = new List<ParserObject>();

            if (parent != null)
                this.Subs.Add(new BackAction(parent));

            foreach (var item in _dir.GetDirectories().Where(filter).Select(c => new DirectoryObject(c, this)))
            {
                
                if (item.Subs.Where(c => !(c is BackAction)).Count() != 0)
                {

                    if (item.Subs.Count == 1)
                        this.Subs.Add(item.Subs[0]);
                    else
                        this.Subs.Add(item);

                }

            }

            foreach (var item in _dir.GetFiles("*.cs").Where(filter).Select(c => new FileAction(c)))
                this.Subs.Add(item);

        }

        private bool filter(DirectoryInfo arg)
        {
            var name = arg.Name;
            return !_toExclude.Contains(name);
        }

        private bool filter(FileInfo arg)
        {
            var name = arg.Name;
            return !_toExclude.Contains(name);
        }


        public override void Click(object sender, ParserObbjectEventArgs e)
        {

            if (e.Button.DataContext != null && e.Button.DataContext is ParserObject p)
            {

                if (p is DirectoryObject d)
                    e.Main.DataContext = d.Subs;

                else if (p is FileAction f)
                {

                }

            }


        }


        public List<ParserObject> Subs { get; }


        private readonly DirectoryInfo _dir;
        private readonly HashSet<string> _toExclude;
        private readonly DirectoryObject _parent;


    }

}



