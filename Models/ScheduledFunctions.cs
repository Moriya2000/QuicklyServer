using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace QuicklyServer.Models
{
    public class ScheduledFunctions
    {
        static CancellationTokenSource m_ctSource;
        public static void RunPrepareDaily(DateTime date)//מקבלת תאריך מדויק
        {
            m_ctSource = new CancellationTokenSource();
            var dateNow = DateTime.Now;
            TimeSpan ts;//אובייקט שמייצג את מרווח הזמן שנותר עד להפעלת התהליך
            if (date > dateNow)
                ts = date - dateNow;
            else//אם התאריך המבוקש עבר כבר-מקדם אותו למועד הבא
            {
                date = date.AddDays(1);//במקרה שלנו- קידום התאריך ביום(יכול להיות גם הוספת דקות/שעות)
                ts = date - dateNow;
            }
            //שימתין את פרק הזמן שנקבע, ואח"כ יקרא לפונקציה שרצינו שתופעל פעם ב... threadהפעלת ה 
            Task.Delay(ts).ContinueWith((x) =>
            {
                SendingCompanyBL.Scheduling();//קריאה לפונקציה המבוקשת
                RunPrepareDaily(date);//קריאה חוזרת לפונקציה...
            }, m_ctSource.Token);

        }
    }
}