
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  Tools_CheckAccount.cs
//  Create on 5/18/2018
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*  Script Editor: EazeyWang                      
/*	Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Text.RegularExpressions;

//public delegate void CheckMessageDelegate(bool isMatch, string message);

public class CheckAccountMessage
{
    public readonly bool IsCorrect;
    public readonly string Message;

    public CheckAccountMessage(bool correct, string message)
    {
        IsCorrect = correct;
        Message = message;
    }
}

public class Tools_CheckAccount
{

    private static CheckAccountMessage GetMessage(bool correct, string message)
    {
        CheckAccountMessage messageObj = null;
        messageObj = new CheckAccountMessage(correct, message);
        return messageObj;
    }

    const string ACCOUNT_PATTERN = @"^[a-zA-z_][a-zA-Z0-9_]{5,17}$";
    const string ACCOUNT_ERROR_MESSAGE = "Just allow the length between 6 and 18," +
                                         " account bans digital to be first character," +
                                         " and account allowed to include dital, charactor and underline.";

    public static CheckAccountMessage CheckAccountNumber(string accountNumber)
    {
        bool correct = Regex.IsMatch(accountNumber, ACCOUNT_PATTERN);
        return GetMessage(correct, ACCOUNT_ERROR_MESSAGE);
    }

    const int STRING_LENGTH = 6;
    const string STRING_ERROR_MESSAGE = "The acoount number or password length little than 6.";

    public static CheckAccountMessage CheckLength(string strs)
    {
        bool correct = (strs.Length >= 6);
        return GetMessage(correct, STRING_ERROR_MESSAGE);
    }

    const string PASSWORD_ERROR_MESSAGE = "The twice password is different.";

    public static CheckAccountMessage CheckPasswordConfirm(string first, string second)
    {
        bool correct = (first == second);
        return GetMessage(correct, PASSWORD_ERROR_MESSAGE);
    }
}

