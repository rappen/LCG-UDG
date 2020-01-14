namespace Rappen.XTB.LCG
{
    public interface IConstantFileWriter
    {
        void WriteBlock(Settings settings, string block, string filename);
        string Finalize(Settings settings);
    }
}
