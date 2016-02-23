# Hotel System


## Idea
Hotel System is application for a hotel group which want to manage all hotels throw one system. The application has client, employee and administration part. 

**Client part** is like every site for hotels, but it is for all hotel in the group. So users will see all hotels the group own and it make the hotel group popular quickly. Like most hotel's sites visitors can book room. 

**Employee part** is the most interesting. It is like desk managing hotel system - when you go to reception and want to book a roomo r you already booked it and now you want to enter in the room, this is the part from the system that show employees information about every room in the hotel, all booking information and they can manage it. 

**Administration part** is only for users with role - Administrator. The have access to every route and action in application. The can manage hotels, rooms, users, add or remove permissions and so on.



## Structure

Hotel System Web - Mvc consists of four Areas for every single logic parts in the application;
- __Administration__ - Administrator user can view, add, edit and delete users, hotels, rooms, booking;
- __Booking__ - This is client side booking. First step is to choose a arrival and departure date, a hotel from hotel group and members capacity. Then it list all free room for given period with capacity equal or bigger than the given one. Every room is displayed with information obaut it - type, room size, features and price. When choose a room it's appear form with booking information that should be field and than send;
- __Hotels__ - Here is the information about every hotel. User can find list with all hotels in hotel group or detail information for some concrete;
- __Profile__ - User orientiert part. Logged user can view it's booking information that ever have made.