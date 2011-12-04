using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Clover.Server
{

    public class CommandHandler
    {
        Dictionary<CommandType, Action<StateObject>> handlers = new Dictionary<CommandType, Action<StateObject>>();

        public CommandHandler()
        {
            var methods = typeof(CommandHandler).GetMethods();

            var fields = Enum.GetNames(typeof(CommandType)).ToList();
            foreach (var item in methods)
            {
                if (item.Name.StartsWith("Handle"))
                {
                    var commandTypeName = item.Name.Substring(6, item.Name.Length - 6);
                    if (fields.Contains(commandTypeName))
                    {
                        CommandType type = (CommandType)Enum.Parse(typeof(CommandType), commandTypeName);
                        handlers[type] = (Action<StateObject>)Delegate.CreateDelegate(typeof(Action<StateObject>), item);

                        fields.Remove(commandTypeName);
                    }
                }
            }
           
          
        }

        public void Call(StateObject state)
        {
            if (!handlers.ContainsKey(state.CommandType))
            {
                DefaultHandle(state);
            }
            handlers[state.CommandType](state);
        }

        #region Delegate Handle Method Name Start with Handle
        public static void HandleUnknown(StateObject state)
        {
            Console.WriteLine("HandleUnknown has called");
            state.WorkSocket.Send(BitConverter.GetBytes(1));
            state.WorkSocket.Send(Encoding.UTF8.GetBytes("Server have received unknown data"));
            state.WorkSocket.Disconnect(true);
            return;
        }
        public static void HandleTest(StateObject state)
        {
            Console.WriteLine("HandleTest has called");
            state.WorkSocket.Send(BitConverter.GetBytes(1));
            state.WorkSocket.Send(Encoding.UTF8.GetBytes("Server have received test data"));
            state.WorkSocket.Disconnect(true);
            return;
        }
        public static void HandledReset(StateObject state)
        {
            Console.WriteLine("HandledReset has called");
        }

        public static void HandledSendHashData(StateObject state)
        {
            Console.WriteLine("HandledReset has called");
        }
        #endregion

        #region default handler if can not find given name
        public static void DefaultHandle(StateObject state)
        {

        }
        #endregion

    }
}
