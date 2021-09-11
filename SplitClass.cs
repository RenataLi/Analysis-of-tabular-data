using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analysis_of_tabular_data
{

    public class SplitClass
    {
        /// <summary>
        /// Using Enums.
        /// </summary>
        private class Context
        {
            public List<char> charlist;
            public State state;
            public char symbol;
            public List<string> strlist;
        }
        private enum State
        {
            Start,
            QuotedValue,
            UnQuotedValue,
            AfterQuote
        }
        private enum Symbol
        {
            Quote,
            Comma,
            Other
        }
        // Method for getting symbol.
        private static Symbol GetSymbol(char c)
        {
            if (c == ','||c==';')
                return Symbol.Comma;
            else if (c == '"')
                return Symbol.Quote;
            else
                return Symbol.Other;
        }
        /// <summary>
        /// We define the necessary events.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static State StartQuote(Context context)
        {
            return State.QuotedValue;
        }
        // Starting comma.
        private static State StartComma(Context context) { context.strlist.Add(""); return State.Start; }
        // Starting other.
        private static State StartOther(Context context) { context.charlist.Add(context.symbol); return State.UnQuotedValue; }
        // Starting quotedvalue.
        private static State QuotedValueQuote(Context context)
        {
            context.strlist.Add(new string(context.charlist.ToArray()));
            context.charlist.Clear();
            return State.AfterQuote;
        }
        // Quoted value other symbols.
        private static State QuotedValueOther(Context context) 
        {
            context.charlist.Add(context.symbol); 
            return State.QuotedValue;
        }
        // Quoted value other comma.
        private static State UnQuotedValueComma(Context context)
        {
            context.strlist.Add(new string(context.charlist.ToArray()));
            context.charlist.Clear();
            return State.Start;
        }
        // Quoted value other symbols.
        private static State UnQuotedValueOther(Context context)
        {
            context.charlist.Add(context.symbol);
            return State.UnQuotedValue;
        }
        // After quoted comma.
        private static State AfterQuotedComma(Context context)
        {
            return State.Start;
        }
        /// <summary>
        /// Spliting string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] Split(string str)
        {
            Func<Context, State>[,] funcs = new Func<Context, State>[,]
            {
                // Using matrix.
                {StartQuote,StartComma,StartOther },
                {QuotedValueQuote,QuotedValueOther,QuotedValueOther },
                {UnQuotedValueOther, UnQuotedValueComma,UnQuotedValueOther },
                { null,AfterQuotedComma,null},
            };
            Context context = new Context { charlist = new List<char>(), state = State.Start, strlist = new List<string>() };
            foreach (var item in str)
            {
                Func<Context, State> func = funcs[(int)context.state, (int)GetSymbol(item)];
                if (func == null) throw new ArgumentException();
                context.symbol = item;
                context.state = func(context);
            }
            if(context.charlist.Count>0)
                context.strlist.Add(new string(context.charlist.ToArray()));
            return context.strlist.ToArray();
        }
    }
}
