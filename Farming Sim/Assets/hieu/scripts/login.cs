using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class login : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MessageText;
    [Header("Login")]
    [SerializeField] TMP_InputField EmailInput;
    [SerializeField] TMP_InputField PasswordInput;
    [SerializeField] GameObject loginPage;
    [Header("Register")]
    [SerializeField] TMP_InputField UsernamRegister;
    [SerializeField] TMP_InputField EmailRegister;
    [SerializeField] TMP_InputField PasswordRegister;
    [SerializeField] GameObject RegisterPage;
    [Header("Recovery")]
    [SerializeField] TMP_InputField EmailRecovery;
    [SerializeField] TMP_InputField RecoveryPage;
    [SerializeField] GameObject Recovery;
    [Header("clear")]
    private string TempName;
    private string TempEmail;
    private string TempPassword;
    #region button
    public void OnloginPage()
    {
        loginPage.SetActive(true);
        RegisterPage.SetActive(false);
        Recovery.SetActive(false);
    }
    public void OpenRegister()
    {
        loginPage.SetActive(false);
        RegisterPage.SetActive(true);
        Recovery.SetActive(false);
    }
    public void OpenRecovery()
    {
        loginPage.SetActive(false);
        RegisterPage.SetActive(false);
        Recovery.SetActive(true);
    }
    #endregion
    public void RegisterUser()
    {
        TempName = UsernamRegister.text;
        TempEmail = EmailRegister.text;
        TempPassword = PasswordRegister.text;
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = TempName,
            Email = TempEmail,
            Password = TempPassword,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, On, OnError);
    }
  
    public void On(RegisterPlayFabUserResult Result)
    {
        MessageText.text = "New Account Is Created";
        OnloginPage();
    }
    public void OnError(PlayFabError error)
    {
        MessageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailInput.text,
            Password = PasswordInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, Onlogin, OnError);
    }

    private void Onlogin(LoginResult result)
    {
        MessageText.text = "Login";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Onrecovery()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailRecovery.text,
            TitleId = "229A0"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, Onrecovery, OnError);
    }

    private void Onrecovery(SendAccountRecoveryEmailResult result)
    {
        OnloginPage();
        MessageText.text = "Recovery Mail Sent";
    }
}
