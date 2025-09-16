namespace DO;

[Serializable]
public class DalNoExistingIdException : Exception
{
    public DalNoExistingIdException(string message):base(message)
    {
        
    }

}

[Serializable]
public class DalAlreadyExistingIdException:Exception
{

    public DalAlreadyExistingIdException(string message):base(message) 
    { 
    }
}
[Serializable]
public class DalNotValidChoiceException : Exception
{
    public DalNotValidChoiceException(string message):base (message)
    {

    }
}



