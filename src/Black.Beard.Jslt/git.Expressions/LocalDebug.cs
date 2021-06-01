namespace Bb
{

    public class LocalDebug
    {

        static LocalDebug()
        {

            LocalDebug.StopActivated = System.Diagnostics.Debugger.IsAttached;

        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public static void Stop()
        {
            if (LocalDebug.StopActivated)
                System.Diagnostics.Debugger.Break();
        }

        public static void Desactivate()
        {
            LocalDebug.StopActivated = false;
        }

        public static void Activate()
        {
            LocalDebug.StopActivated = true;
        }

        public static bool StopActivated { get; private set; }

    }

}
