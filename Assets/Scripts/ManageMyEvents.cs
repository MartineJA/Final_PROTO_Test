using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Il s'agit de g�rer la r�solution ou non des �nigmes par des events.
/// Je reprends la m�me structure de code que pour le jeu Sally (Archero Like)
///
/// </summary>
public class ManageMyEvents : MonoBehaviour
{
    public delegate void MyDelegate();
    public static event MyDelegate OnButtonPushed;
    public static event MyDelegate OnSolutionFound;
    public static event MyDelegate OnBadAnswer;

    public static event MyDelegate OnTutoDoor;

    public static void NotifyButtonPushed() {  OnButtonPushed?.Invoke(); }
    public static void NotifySolutionFound() {  OnSolutionFound?.Invoke(); }
    public static void NotifyBadAnswer() {  OnBadAnswer?.Invoke(); }

    public static void NotifyTutoDoor() {  OnTutoDoor?.Invoke(); }


}
