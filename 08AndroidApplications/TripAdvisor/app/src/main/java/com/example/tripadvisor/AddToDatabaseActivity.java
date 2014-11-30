package com.example.tripadvisor;

import android.app.Activity;
import android.app.ListActivity;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Toast;

import com.telerik.everlive.sdk.core.EverliveApp;
import com.telerik.everlive.sdk.core.model.system.DownloadedFile;
import com.telerik.everlive.sdk.core.query.definition.FileField;
import com.telerik.everlive.sdk.core.result.RequestResult;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;

import database.Place;
import database.PlaceDataSource;


public class AddToDatabaseActivity extends ListActivity {


    public  static List<Place> allPlacesFromTheBase = new ArrayList<Place>();
    public EverliveApp app = new EverliveApp("iEFw0m2S2kX61YKR");
    public static PlaceDataSource datasource;
    final Context context = this;
    //  private  String picturePath;
    String titlePlace = (AddPlaceActivity.title).getText().toString();
    String descriptionPlace = (AddPlaceActivity.description).getText().toString();
    String longitudePic = (AddPlaceActivity.longitudeValue);
    String latitudePic = (AddPlaceActivity.latitudeValue);
    String pictureInfo = AddPlaceActivity.pictureName;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_to_database);


        datasource = new PlaceDataSource(this);
        datasource.open();

        allPlacesFromTheBase = datasource.getAllPlaces();

        List<String> placesNames = new ArrayList<String>();

        for (Place item : allPlacesFromTheBase) {
            placesNames.add(item.getTitle());
        }

        // use the SimpleCursorAdapter to show the
        // elements in a ListView
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
                android.R.layout.simple_list_item_1, placesNames);
        setListAdapter(adapter);

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.add_to_database, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }


    public void onClick(View view) {
        if (view.getId() == R.id.button_add_to_database) {


            ArrayAdapter<String> adapter = (ArrayAdapter<String>) getListAdapter();
            Place place = null;

            place = datasource.createPlace(titlePlace, descriptionPlace, longitudePic, latitudePic, pictureInfo);

            adapter.add(place.getTitle());

            new UploadPicture().start();

            Toast.makeText(context, "Place successfully added!", Toast.LENGTH_SHORT).show();
        }
        else  if (view.getId() == R.id.go_to_gallery) {


            Intent intent = new Intent(AddToDatabaseActivity.this,
                    GalleryActivity.class);
            this.startActivity(intent);
        }
    }

    //Backend Services
    private class UploadPicture extends Thread {
        @Override
        public void run() {
            super.run();
            try {
                Bitmap si = AddPlaceActivity.pic;

                ByteArrayOutputStream stream = new ByteArrayOutputStream();
                si.compress(Bitmap.CompressFormat.JPEG, 100, stream);
                InputStream is = new ByteArrayInputStream(stream.toByteArray());


//                InputStream is = new FileInputStream("/mnt/emmc/DCIM/100MEDIA/IMAG1076.jpg");
                UploadFile(app, pictureInfo + ".jpg", "image/jpeg", is);
                is.close();
                Log.i("File", "Uploaded");
            } catch (IOException e) {
                Log.i("ERROR", "Upload ERROR");
            }
        }

        public void UploadFile(EverliveApp app, String fileName, String contentType, InputStream inputStream) {
            FileField fileField = new FileField(fileName, contentType, inputStream);
            app.workWith().files().upload(fileField).executeSync();
            Log.i("UploadFile", "Upload");
        }
    }
}
