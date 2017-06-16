namespace LGU
{
    public class MainWindowRedirectionOptions
    {
        public static void Redirect(string target)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                throw LGUException.ArgumentNullOrWhiteSpace(nameof(target), "Redirection target is null or white space.");
            }

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
