using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wizards
{

    public class DirectoryObject : ParserObject
    {


        public DirectoryObject(DirectoryInfo dir, DirectoryObject parent)
            : base(dir.Name)
        {

            this._parent = parent;
            this._dir = dir;

            this.Subs = new List<ParserObject>();


            if (parent != null)
                this.Subs.Add(new BackAction(parent));

            this.Subs.AddRange(_dir.GetDirectories().Select(c => new DirectoryObject(c, this)));

            this.Subs.AddRange(_dir.GetFiles("*.cs").Select(c => new FileAction(c)));

        }

        public override void Click(object sender, ParserObbjectEventArgs e)
        {


            if (e.Button.DataContext != null && e.Button.DataContext is ParserObject p)
            {

                if (p is DirectoryObject d)
                {
                    
                    e.Main.DataContext = d.Subs;

                }
                else if (p is FileAction f)
                {

                }



            }


        }


        public List<ParserObject> Subs { get; }


        private readonly DirectoryInfo _dir;
        private readonly DirectoryObject _parent;


    }

}



