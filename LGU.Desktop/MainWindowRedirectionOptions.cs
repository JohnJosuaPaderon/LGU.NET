namespace LGU
{
    public class MainWindowRedirectionOptions
    {
        public static void Redirect(string target)
        {
            Instance = new MainWindowRedirectionOptions(true, target);
        }

        public static MainWindowRedirectionOptions Instance { get; private set; }

        private MainWindowRedirectionOptions(bool redirectToTarget, string target)
        {
            RedirectToTarget = redirectToTarget;
            Target = target;
        }

        public bool RedirectToTarget { get; }
        public string Target { get; }
    }
}
