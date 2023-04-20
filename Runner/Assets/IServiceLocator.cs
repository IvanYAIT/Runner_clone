public interface IServiceLocator
{
    bool GetService<T>(out T service);
    bool RegisterService<T>(T service);
    bool RemoveService<T>(T service);
}