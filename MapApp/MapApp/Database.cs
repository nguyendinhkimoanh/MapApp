﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapApp
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool createDatabase()
        {
            try
            {
                //Tạo csdl
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlDes.db")))
                {
                    //Tạo 2 bảng
                    connection.CreateTable<Node>();
                    connection.CreateTable<Place>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                //Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        /*------------------------------------------------------------------------------------*/

        public bool insertNode(Node node)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlDes.db")))
                {
                    connection.Insert(node);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public List<Node> selectNode()
        {
            try
            {
                using (var connection = new SQLiteConnection (System.IO.Path.Combine(folder, "qlDes.db")))
                {
                    return connection.Table<Node>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        /*------------------------------------------------------------------------------------*/

        public bool insertPlace(Place place)
        {
            try
            {
                using (var connection = new  SQLiteConnection(System.IO.Path.Combine(folder, "qlDes.db")))
                {
                    connection.Insert(place);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public List<Place> selectPlace()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlDes.db")))
                {
                    return connection.Table<Place>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
    }
}
