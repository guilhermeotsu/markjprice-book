namespace PacktLibrary
{
    public class Thing
    {
        public object Data = default(object);
        public string Process(object input)
        {
            if(Data == input) 
                return "Data e input sao o mesmo!";
            
            return "Data e input NAO sao o mesmo!";
        }
    }
}