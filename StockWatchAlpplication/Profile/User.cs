﻿namespace Profile
{
    using System;
    using System.Windows.Forms;
    using Firebase.Auth;
    using Utils;

    public class User : IUser
    {
        public async void SignUp(string email, string password)
        {
            try
            {
                SimpleValidator.CheckNullOrEmpty(email, "email");
                SimpleValidator.CheckNullOrEmpty(password, "password");
            }
            catch (ArgumentException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Invalid email or password", e.Message, buttons);
                return;
            }

            if (password.Length < 6)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Password must be at least 6 chars long", "", buttons);
                return;
            }


            // teamelderberry.firebaseapp.com
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCs3jVuwKl9ntdSaJWvGqzAzGoVX7Xblk4"));

            try
            {
                // TODO: Use auth link to implement storage of some user preferences, like portfolio
                var authLink = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
            }
            catch (FirebaseAuthException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                if (e.Reason.ToString().Equals("EmailExists"))
                {
                    MessageBox.Show("The account already exists", "", buttons);
                }
                else
                {
                    MessageBox.Show(e.Reason.ToString(), "", buttons);
                }

                return;
            }


            //// Sign up successful, notify and redirect to main Form
            //MainForm main = Application.OpenForms["MainForm"] as MainForm;

            //if (main != null)
            //{
            //    main.ShowDialog();
            //}
            //else
            //{
            //    new MainForm().ShowDialog();
            //}
        }

        public bool SignIn(string email, string password)
        {
            try
            {
                SimpleValidator.CheckNullOrEmpty(email, "email");
                SimpleValidator.CheckNullOrEmpty(password, "password");
            }
            catch (ArgumentException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Invalid email or password", e.Message, buttons);
                return false;
            }

            if (password.Length < 6)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Password must be at least 6 chars long", "", buttons);
                return false;
            }


            // teamelderberry.firebaseapp.com
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCs3jVuwKl9ntdSaJWvGqzAzGoVX7Xblk4"));

            try
            {
                // TODO: Figure out what to do with the response
                //var authLink = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (FirebaseAuthException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(e.Reason.ToString(), "", buttons);

                return false;
            }


            //// Sign in successful, notify and redirect to main Form
            //MainForm main = Application.OpenForms["MainForm"] as MainForm;

            //if (main != null)
            //{
            //    main.ShowDialog();
            //}
            //else
            //{
            //    new MainForm().ShowDialog();
            //}
        }
    }
}
