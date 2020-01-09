namespace Rappen.XTB.LCG
{
    public interface IConstantFileWriter
    {
        void WriteEntity(Settings settings, string entity, string filename);
        string Finalize(Settings settings);
    }
}
