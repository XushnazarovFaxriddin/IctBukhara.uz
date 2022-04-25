namespace IctBukhara.uz.Models.ViewModels
{
    using System.Collections.Generic;
    public class IndexView
    {
        public IEnumerable<Mentor> Mentorlar { get; set; }
        public IEnumerable<Kurs> Kurslar { get; set; }
    }
}
