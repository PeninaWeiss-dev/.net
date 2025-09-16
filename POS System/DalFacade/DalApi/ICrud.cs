﻿
namespace DalApi;
public interface ICrud<T>
{
    int Create(T item); //Creates new entity object in DAL
    T? Read(Func<T,bool>filter); //Reads entity object by its ID 
    T? ReadById(int id);
    List<T?> ReadAll(Func<T,bool>? filter=null); 
    void Update(T item); //Updates entity object
    void Delete(int id); //Deletes an object by its 
}
