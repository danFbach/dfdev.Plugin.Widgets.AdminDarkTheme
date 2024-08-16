let adminDarkTheme = {
  ActiveTheme: () => {
    if (document.querySelector('html').classList.contains('dark')) {
      return 'dark';
    } else if (document.querySelector('html').classList.contains('light')) {
      return 'light';
    }
    return null;
  },

  SelectedTheme: () => {
    return localStorage.getItem('adminThemePreference');
  },

  PreferredTheme: () => {
    return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
  },

  Toggle: () => {
    adminDarkTheme.CheckIfPreferredIsSet(adminDarkTheme.SelectedTheme() == 'dark' ? 'light' : 'dark', true);
  },

  CheckIfPreferredIsSet: (newTheme = null, wasToggled = false) => {

    if (newTheme == null) {
      newTheme = adminDarkTheme.SelectedTheme() != null ? adminDarkTheme.SelectedTheme() : adminDarkTheme.PreferredTheme();
    }

    if (adminDarkTheme.SelectedTheme() != adminDarkTheme.PreferredTheme() || adminDarkTheme.SelectedTheme() != newTheme ||
      (adminDarkTheme.ActiveTheme() != null && adminDarkTheme.ActiveTheme() != adminDarkTheme.SelectedTheme())) {

      localStorage.setItem('adminThemePreference', newTheme);

      if (adminDarkTheme.SelectedTheme() == 'dark') {
        document.querySelector('html').classList.remove('light');
        if (adminDarkTheme.SelectedTheme() != adminDarkTheme.PreferredTheme()) {
          document.querySelector('html').classList.add('dark');
        }
      } else {
        document.querySelector('html').classList.remove('dark');
        if (adminDarkTheme.SelectedTheme() != adminDarkTheme.PreferredTheme()) {
          document.querySelector('html').classList.add('light');
        }
      }
    }
  },
};
adminDarkTheme.CheckIfPreferredIsSet();

document.addEventListener("visibilitychange", () => {
  TabIsHidden = document.visibilityState === "hidden";
  if (!TabIsHidden)
    adminDarkTheme.CheckIfPreferredIsSet();
}, false);