namespace PictureConverter
{
    public class PictureConverter
    {
        public static bool ConvertPictureTranslucentPixelsToTransparent(string pictureFullPath)
        {
            try
            {
                using Image<Rgba32> image = Image.Load<Rgba32>(pictureFullPath);

                image.ProcessPixelRows(accessor =>
                {

                    for (int y = 0; y < accessor.Height; y++)
                    {
                        Span<Rgba32> pixelRow = accessor.GetRowSpan(y);

                        for (int x = 0; x < pixelRow.Length; x++)
                        {
                            ref Rgba32 pixel = ref pixelRow[x];
                            if (pixel.A < 10.0)
                            {
                                pixel.A = 0;
                            }
                        }
                    }
                });
                image.Save(pictureFullPath);

                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}