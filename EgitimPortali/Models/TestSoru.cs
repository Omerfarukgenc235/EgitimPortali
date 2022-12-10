using EgitimPortali.Models.Base;

namespace EgitimPortali.Models
{
    public class TestSoru : BaseModel
    {
        public int TestId { get; set; }
        public Test Test { get; set; }
        public string Soru { get; set; }
        public string CevapA { get; set; }
        public string CevapB { get; set; }
        public string CevapC { get; set; }
        public string CevapD { get; set; }
        public string CevapE { get; set; }
        public int DogruCevap { get; set; }
        public ICollection<TestCevap> TestinCevaplari { get; set; }
    }
}
