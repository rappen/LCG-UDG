namespace Rappen.XTB.LCG
{
    public interface IConstantFileWriter
    {
        void WriteBlock(Settings settings, string block, string filename);
        bool Finalize(Settings settings);
        string GetResult(Settings settings);
    }
}
