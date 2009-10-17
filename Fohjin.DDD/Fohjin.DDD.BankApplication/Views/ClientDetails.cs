﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Fohjin.DDD.BankApplication.Presenters;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.BankApplication.Views
{
    public partial class ClientDetails : Form, IClientDetailsView
    {
        private IClientDetailsPresenter _presenter;

        public ClientDetails()
        {
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        public string ClientName
        {
            get { return _clientName.Text; }
            set { _clientName.Text = value; }
        }

        public string Street
        {
            get { return _street.Text; }
            set { _street.Text = value; }
        }

        public string StreetNumber
        {
            get { return _streetNumber.Text; }
            set { _streetNumber.Text = value; }
        }

        public string PostalCode
        {
            get { return _postalCode.Text; }
            set { _postalCode.Text = value; }
        }

        public string City
        {
            get { return _city.Text; }
            set { _city.Text = value; }
        }

        public IEnumerable<Account> Accounts
        {
            get { return (IEnumerable<Account>)_accounts.DataSource; }
            set { _accounts.DataSource = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber.Text; }
            set { _phoneNumber.Text = value; }
        }

        public string NewAccountName
        {
            get { return _newAccountName.Text; }
            set { _newAccountName.Text = value; }
        }

        public string ClientNameLabel
        {
            set { _clientNameLabel.Text = value; }
        }

        public string AddressLine1Label
        {
            set { _addressLine1Label.Text = value; }
        }

        public string AddressLine2Label
        {
            set { _addressLine2Label.Text = value; }
        }

        public string PhoneNumberLabel
        {
            set { _phoneNumberLabel.Text = value; }
        }

        public void SetPresenter(IClientDetailsPresenter clientDetailsPresenter)
        {
            _presenter = clientDetailsPresenter;
        }

        public Account GetSelectedAccount()
        {
            return (Account)_accounts.SelectedItem;
        }

        public void DisableAddNewAccountMenu()
        {
            addNewAccountToolStripMenuItem.Enabled = false;
        }

        public void EnableClientHasMovedMenu()
        {
            hasMovedToolStripMenuItem.Enabled = true;
        }

        public void DisableClientHasMovedMenu()
        {
            hasMovedToolStripMenuItem.Enabled = false;
        }

        public void EnableNameChangedMenu()
        {
            nameChangedToolStripMenuItem.Enabled = true;
        }

        public void DisableNameChangedMenu()
        {
            nameChangedToolStripMenuItem.Enabled = false;
        }

        public void EnablePhoneNumberChangedMenu()
        {
            changedHisPhoneNumberToolStripMenuItem.Enabled = true;
        }

        public void DisablePhoneNumberChangedMenu()
        {
            changedHisPhoneNumberToolStripMenuItem.Enabled = false;
        }

        public void EnableAddNewAccountMenu()
        {
            addNewAccountToolStripMenuItem.Enabled = true;
        }

        public void EnableSaveButton()
        {
            _addressSaveButton.Enabled = true;
            _phoneNumberSaveButton.Enabled = true;
            _clientNameSaveButton.Enabled = true;
            _newAccountCreateButton.Enabled = true;
        }

        public void DisableSaveButton()
        {
            _addressSaveButton.Enabled = false;
            _phoneNumberSaveButton.Enabled = false;
            _clientNameSaveButton.Enabled = false;
            _newAccountCreateButton.Enabled = false;
        }

        public void EnableOverviewPanel()
        {
            tabControl1.SelectedIndex = 0;
        }

        public void EnableAddressPanel()
        {
            tabControl1.SelectedIndex = 1;
        }

        public void EnablePhoneNumberPanel()
        {
            tabControl1.SelectedIndex = 2;
        }

        public void EnableClientNamePanel()
        {
            tabControl1.SelectedIndex = 3;
        }

        public void EnableAddNewAccountPanel()
        {
            tabControl1.SelectedIndex = 4;
        }

        private void _accounts_DoubleClick(object sender, EventArgs e)
        {
            _presenter.OpenSelectedAccount();
        }

        private void _client_Changed(object sender, EventArgs e)
        {
            _presenter.FormElementGotChanged();
        }

        private void addNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.InitiateAddNewAccount();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _presenter.Cancel();
        }

        private void _clientNameSaveButton_Click(object sender, EventArgs e)
        {
            _presenter.SaveNewClientName();
        }

        private void _phoneNumberSaveButton_Click(object sender, EventArgs e)
        {
            _presenter.SaveNewPhoneNumber();
        }

        private void _addressSaveButton_Click(object sender, EventArgs e)
        {
            _presenter.SaveNewAddress();
        }

        private void nameChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.InitiateClientNameChange();
        }

        private void hasMovedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.InitiateClientHasMoved();
        }

        private void changedHisPhonenumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.InitiateClientPhoneNumberChanged();
        }

        private void NewAccountCancelButton_Click(object sender, EventArgs e)
        {
            _presenter.Cancel();
        }

        private void NewAccountCreateButton_Click(object sender, EventArgs e)
        {
            _presenter.CreateNewAccount();
        }
    }
}