package database;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;

import java.util.ArrayList;
import java.util.List;

public class PlaceDataSource {
    // Database fields
    private SQLiteDatabase database;
    private mySQLLiteHelper dbHelper;
    private String[] allColumns = {mySQLLiteHelper.COLUMN_ID,
            mySQLLiteHelper.COLUMN_TITLE, mySQLLiteHelper.COLUMN_DESCRIPTION,
            mySQLLiteHelper.COLUMN_LONGITUDE, mySQLLiteHelper.COLUMN_LATITUDE,
            mySQLLiteHelper.COLUMN_PICTUREPATH};

    public PlaceDataSource(Context context) {
        dbHelper = new mySQLLiteHelper(context);
    }

    public void open() throws SQLException {
        database = dbHelper.getWritableDatabase();
    }

    public void close() {
        dbHelper.close();
    }

    public Place createPlace(String title, String description, String longitude,
                             String latitude, String picturePath) {
        ContentValues values = new ContentValues();
        values.put(mySQLLiteHelper.COLUMN_TITLE, title);
        values.put(mySQLLiteHelper.COLUMN_DESCRIPTION, description);
        values.put(mySQLLiteHelper.COLUMN_LONGITUDE, longitude);
        values.put(mySQLLiteHelper.COLUMN_LATITUDE, latitude);
        values.put(mySQLLiteHelper.COLUMN_PICTUREPATH, picturePath);

        long insertId = database.insert(mySQLLiteHelper.TABLE_PLACES, null,
                values);
        Cursor cursor = database.query(mySQLLiteHelper.TABLE_PLACES,
                allColumns, mySQLLiteHelper.COLUMN_ID + " = " + insertId, null,
                null, null, null);
        cursor.moveToFirst();
        Place newPlace = cursorToPlace(cursor);
        cursor.close();
        return newPlace;
    }



//    public void deleteComment(Comment comment) {
//        long id = comment.getId();
//        System.out.println("Comment deleted with id: " + id);
//        database.delete(mySQLLiteHelper.TABLE_COMMENTS, mySQLLiteHelper.COLUMN_ID
//                + " = " + id, null);
//    }

    public List<Place> getAllPlaces() {
        List<Place> places = new ArrayList<Place>();

        Cursor cursor = database.query(mySQLLiteHelper.TABLE_PLACES,
                allColumns, null, null, null, null, null);

        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            Place place = cursorToPlace(cursor);
            places.add(place);
            cursor.moveToNext();
        }
        // make sure to close the cursor
        cursor.close();
        return places;
    }

    private Place cursorToPlace(Cursor cursor) {
        Place place = new Place();
        place.setId(cursor.getLong(0));
        place.setTitle(cursor.getString(1));
        place.setDescription(cursor.getString(2));
        place.setLongitude(cursor.getString(3));
        place.setLatitude(cursor.getString(4));
        place.setPicture(cursor.getString(5));
        return place;
    }
}
