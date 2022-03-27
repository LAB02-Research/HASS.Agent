namespace HASSAgent.Functions
{
    /// <summary>
    /// Makes sure our form is completely hidden on startup
    /// <para>Source: https://www.mking.net/blog/setting-a-winforms-form-to-be-hidden-on-startup </para>
    /// </summary>
    public class CustomApplicationContext : ApplicationContext
    {
        private Form _mainForm;
        
        public CustomApplicationContext(Form mainForm)
        {
            _mainForm = mainForm;
            if (_mainForm == null) return;
            
            // Wire up the destroy events similar to how the base ApplicationContext
            // does things when a form is provided.
            _mainForm.HandleDestroyed += OnFormDestroy;

            // We still want to call Show() here, but we can at least hide it from the user
            // by setting Opacity to 0 while the form is being shown for the first time.
            _mainForm.Opacity = 0;
            _mainForm.Show();
            _mainForm.Hide();
            _mainForm.Opacity = 1;
        }

        /// <summary>
        /// Handles the <see cref="Control.HandleDestroyed"/> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        private void OnFormDestroy(object sender, EventArgs e)
        {
            if (sender is not Form form || form.RecreatingHandle) return;

            form.HandleDestroyed -= OnFormDestroy;
            OnMainFormClosed(sender, e);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// true if invoked from the <see cref="IDisposable.Dispose"/> method;
        /// false if invoked from the finalizer.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_mainForm != null)
                {
                    if (!_mainForm.IsDisposed) _mainForm.Dispose();
                    _mainForm = null;
                }
            }

            base.Dispose(disposing);
        }
    }

}
