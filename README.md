VR Travel 
=========

Hi! I hope you enjoyed my MSDN article [VR Apps and Unity](https://msdn.microsoft.com/magazine/mt763231). Here is the code discussed in thhe article. To keep it easy to review I have added the Assets, Library and ProjectSettings files so you could just pull the code and open it right in Unity.

Getting Started
---------------
* First, pull down the code found here to your local repos
* Once the code is on your machine, open [Unity](http://www.unity3d.com) (this was built with Unity 5.3.5).
* When you have the code open in Unity, make sure to get your osig file from [Oculus Developer Tools](https://dashboard.oculus.com/tools/osig-generator/)
* Add the osig file to Assets/Plugins/Andriod/assets/

What about the Services
-----------------------
I have not included the services code here but you will need to have services or mocked objects to see the travelers. The Traveler object is very basic in setup using the following format:

```csharp
public class Traveler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
```

Build up the Traveler API in whatever language you prefer. I used ASP.NET WebAPI but as long as the signature is the same as above, you can use whatever you need.

Happy coding!
-------------
