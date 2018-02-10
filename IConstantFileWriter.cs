namespace Rappen.XTB.LCG
{
    public interface IConstantFileWriter
    {
        string GetCompleteMessage(Settings settings);
        void WriteEntity(Settings settings, string entity, string filename);
    }
}
