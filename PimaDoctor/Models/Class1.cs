namespace PimaDoctor.Models
{
    public class Class1
    {
        public bool Open { get; set; }

        public Class1 (string isOpen)
        {
            if (isOpen == "true")
            {
                Open = true;
                return;
            }
            else if (isOpen == "false")
            {
                Open = false;
            }

            Open = false;
        }
    }
}