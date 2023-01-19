// See https://aka.ms/new-console-template for more information

using LabbMongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

IIO io;
DAO dao;
Menus menus = new Menus();

///Databas-connection
io = new TextIO();
dao = new MongoDAO("HelloCluster", "Fighters", "mongodb+srv://Nugget:<password>@hellocluster.xuwc6gc.mongodb.net/?retryWrites=true&w=majority");
///Starta programmet

bool isAdmin = menus.IsAdmin();
InventoryController fighterController = new InventoryController(io, dao); //Här styrs programmet
if (isAdmin) 
{
    fighterController.AdminStart();  
}
else
{
    fighterController.UserStart();
}