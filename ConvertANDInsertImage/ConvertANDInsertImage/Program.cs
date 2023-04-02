

using Microsoft.EntityFrameworkCore;

namespace ConvertANDInsertImage
{
    class program
    {
        // private ISMSSenderService smsSenderService = new SMSSenderService();

        static async Task Main(string[] args)
        {
            long[] arr = {26032,26036,26038,26042,26050 };
            using (GBContext db=new GBContext())
            {
                int inc = 0;
                var lst = db.sELECTECandidates/*.Where(x=> arr.Contains(x.ApplicantionId) )*/.ToList();
                foreach(var l in lst)
                {
                    inc += 1;
                    string imagePath = @"/ApplicantImage";
                    DirectoryInfo dir_img = new DirectoryInfo(imagePath);
                    FileInfo[] files_img = dir_img.GetFiles(l.Name+"_"+l.ApplicantionId+"_*", SearchOption.TopDirectoryOnly);
                    foreach (var item in files_img)
                    {
                        byte[] file;
                        using (var stream = new FileStream(item.FullName, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                file = reader.ReadBytes((int)stream.Length);

                                l.ApplicantImage = file;
                                l.ApplicantImagePath = item.FullName;
                            }
                        }
                    }
                    string signaturePath = @"/ApplicantImage";
                    DirectoryInfo dir_sign = new DirectoryInfo(signaturePath);
                    FileInfo[] files_sign = dir_sign.GetFiles(l.Name + "_" + l.ApplicantionId + "_*", SearchOption.TopDirectoryOnly);
                    foreach (var item in files_sign)
                    {
                        byte[] file;
                        using (var stream = new FileStream(item.FullName, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                file = reader.ReadBytes((int)stream.Length);

                                l.ApplicantSignature = file;
                                l.ApplicantSignaturePath= item.FullName;
                            }
                        }
                    }
                    var obj = db.sELECTECandidates.FirstOrDefault(x => x.ApplicantionId == l.ApplicantionId);
                    obj.ApplicantImage = l.ApplicantImage;
                    obj.ApplicantSignature= l.ApplicantSignature;
                    db.Update(obj);
                    db.SaveChanges();
                    Console.WriteLine(inc);
                }
            }
        }
    }

}