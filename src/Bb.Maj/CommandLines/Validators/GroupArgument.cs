using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;

namespace Bb.CommandLines.Validators
{

    internal class GroupArgument
    {


        public GroupArgument(CommandLineApplication config/*, bool mustBeAuthenticated*/)
        {
            //_mustBeAuthenticated = mustBeAuthenticated;
            _config = config;
            _dicArgument = new Dictionary<CommandArgument, ContainerArgument>();
            _dicOption = new Dictionary<CommandOption, ContainerOption>();
        }



        public CommandOption OptionNoValue(string name, string Description, params Func<CommandOption, int>[] validators)
        {
            return Option(name, Description, CommandOptionType.NoValue, validators);
        }

        public CommandOption Option(string name, string Description, params Func<CommandOption, int>[] validators)
        {
            return Option(name, Description, CommandOptionType.SingleValue, validators);
        }

        public CommandOption OptionMultiValue(string name, string Description, params Func<CommandOption, int>[] validators)
        {
            return Option(name, Description, CommandOptionType.MultipleValue, validators);
        }

        public CommandOption Option(string name, string Description, CommandOptionType value, params Func<CommandOption, int>[] validators)
        {
            var cmd = _config.Option(name, Description, value);
            Validate(cmd, validators);
            return cmd;
        }

        public CommandOption Validate(CommandOption cmd, params Func<CommandOption, int>[] validators)
        {

            if (!_dicOption.TryGetValue(cmd, out ContainerOption list))
                _dicOption.Add(cmd, list = new ContainerOption(cmd));

            foreach (var item in validators)
                list.Add(item);

            return cmd;

        }




        public CommandArgument Argument(string name, string Description, params Func<CommandArgument, int>[] validators)
        {
            return Argument(name, Description, false, validators);
        }

        public CommandArgument Argument(string name, string Description, bool multipleValues, params Func<CommandArgument, int>[] validators)
        {

            var cmd = _config.Argument(name, Description, multipleValues);

            Validate(cmd, validators);

            return cmd;

        }

        public CommandArgument Validate(CommandArgument cmd, params Func<CommandArgument, int>[] validators)
        {

            if (!_dicArgument.TryGetValue(cmd, out ContainerArgument list))
                _dicArgument.Add(cmd, list = new ContainerArgument(cmd));

            foreach (var item in validators)
                list.Add(item);

            return cmd;

        }

        internal bool Evaluate(out int errorNum)
        {

            errorNum = 0;

            foreach (var item in _dicArgument)
            {
                var r = item.Value.Evaluate();
                if (r > 0)
                    errorNum = r;
            }

            foreach (var item in _dicOption)
            {
                var r = item.Value.Evaluate();
                if (r > 0)
                    errorNum = r;
            }

            return errorNum == 0;

        }

        private class ContainerArgument
        {

            private readonly CommandArgument cmd;
            private readonly List<Func<CommandArgument, int>> _list1;

            public ContainerArgument(CommandArgument cmd)
            {
                this.cmd = cmd;
                _list1 = new List<Func<CommandArgument, int>>();
            }

            internal void Add(Func<CommandArgument, int> item)
            {
                _list1.Add(item);
            }

            internal int Evaluate()
            {

                int result = 0;
                foreach (var item in _list1)
                {

                    var r = item(cmd);
                    if (r > 0)
                        result = r;

                }

                return result;

            }

        }

        private class ContainerOption
        {

            private readonly CommandOption cmd;
            private readonly List<Func<CommandOption, int>> _list1;

            public ContainerOption(CommandOption cmd)
            {
                this.cmd = cmd;
                _list1 = new List<Func<CommandOption, int>>();
            }

            internal void Add(Func<CommandOption, int> item)
            {
                _list1.Add(item);
            }

            internal int Evaluate()
            {

                int result = 0;
                foreach (var item in _list1)
                {

                    var r = item(cmd);
                    if (r > 0)
                        result = r;

                }

                return result;

            }

        }

        //public bool _mustBeAuthenticated { get; }
        private readonly CommandLineApplication _config;
        private Dictionary<CommandArgument, ContainerArgument> _dicArgument = new Dictionary<CommandArgument, ContainerArgument>();
        private readonly Dictionary<CommandOption, ContainerOption> _dicOption = new Dictionary<CommandOption, ContainerOption>();

    }

}
