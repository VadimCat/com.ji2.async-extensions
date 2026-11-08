using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ji2Core.AsyncExtensions
{
    public static class AsyncExtensions
    {
        public static async void SoftForget(this UniTask task, 
            Action<Exception> exceptionHandler = null)
        {
            try
            {
                await task;
            }
            catch (OperationCanceledException e)
            {
                Debug.Log(e.Message);
            }
            catch (Exception e)
            {
                if (exceptionHandler != null)
                    exceptionHandler(e);
                else
                    Debug.LogException(e);
            }
        }
    }
}