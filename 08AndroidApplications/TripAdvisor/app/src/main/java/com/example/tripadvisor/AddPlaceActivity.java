package com.example.tripadvisor;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;
import android.content.Context;

import java.util.Random;


public class AddPlaceActivity extends Activity implements View.OnClickListener {

    private Button btnAddPicture, btnCreatePlace;
    final Context context = this;
    // private ImageView mView;
    public static EditText title, description;
    public static String longitudeValue = "#";
    public static String latitudeValue = "#";
    public static String pictureName = "#";
    public  static  Bitmap pic;


    //****************************************//
    private MyLocationListener locationListener;
    private LocationManager lm;
    //    private Location finalLocation;
    private Location toastLocation;
    //****************************************//


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_place);

        btnAddPicture = (Button) this.findViewById(R.id.picture_button);
        btnCreatePlace = (Button) this.findViewById(R.id.create_button);
        btnAddPicture.setOnClickListener(this);
        btnCreatePlace.setOnClickListener(this);
        // mView = (ImageView) findViewById(R.id.imageView3);

        //**************************************************************//
        locationListener = new MyLocationListener();
        lm = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
        //**************************************************************//


    }

    //******************************************************************//
    @Override
    protected void onResume() {
        super.onResume();
        //1sec,1000m
        lm.requestLocationUpdates(LocationManager.GPS_PROVIDER, 1000, 1000, getLocationListener());
    }

    public Location getToastLocation() {
        return toastLocation;
    }

    public void setToastLocation(Location toastLocation) {
        this.toastLocation = toastLocation;
    }


    public MyLocationListener getLocationListener() {
        return locationListener;
    }

    private class MyLocationListener implements LocationListener {

        @Override
        public void onLocationChanged(Location location) {
            if (location != null) {
                Toast.makeText(
                        getBaseContext(),
                        "Location changed: \nLat: " + location.getLatitude()
                                + "\nLong: " + location.getLongitude(),
                        Toast.LENGTH_SHORT).show();

//                finalLocation=location;
                setToastLocation(location);

                longitudeValue = String.valueOf(location.getLongitude());
                latitudeValue = String.valueOf(location.getLatitude());

            }
        }

        @Override
        public void onStatusChanged(String provider, int status, Bundle extras) {
            String statusString = "";
            switch (status) {
                case android.location.LocationProvider.AVAILABLE:
                    statusString = "available";
                case android.location.LocationProvider.OUT_OF_SERVICE:
                    statusString = "out of service";
                case android.location.LocationProvider.TEMPORARILY_UNAVAILABLE:
                    statusString = "temporarily unavailable";
            }
            Toast.makeText(getBaseContext(), provider + " " + statusString,
                    Toast.LENGTH_SHORT).show();
        }

        @Override
        public void onProviderEnabled(String provider) {
            Toast.makeText(
                    getBaseContext(),
                    "Provider: " + provider + " enabled",
                    Toast.LENGTH_SHORT).show();
        }

        @Override
        public void onProviderDisabled(String provider) {
            Toast.makeText(
                    getBaseContext(),
                    "Provider: " + provider + " disabled",
                    Toast.LENGTH_SHORT).show();
        }
    }
    //******************************************************************//


    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        // TODO Auto-generated method stub
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode == RESULT_OK) {
            Bundle extras = data.getExtras();
            Bitmap photo = (Bitmap) extras.get("data");
            pic = photo;

            //Add picture name
            Random rand = new Random();
            int randomNum = rand.nextInt((9999 - 100) + 1) + 100;
            int randomNum2 = rand.nextInt((9999 - 100) + 1) + 100;
            pictureName = "rosi" + randomNum + "dancho" + randomNum2;
            Toast.makeText(context, "Picture added successfully", Toast.LENGTH_SHORT)
                    .show();

        }
    }

    private void startCamera() {
        Intent camera = new Intent(
                android.provider.MediaStore.ACTION_IMAGE_CAPTURE);
        this.startActivityForResult(camera, 100);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.add_place, menu);
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

    @Override
    public void onClick(View view) {
        if (view.getId() == R.id.picture_button) {
            startCamera();
        }
        if (view.getId() == R.id.create_button) {
//            Toast.makeText(context, "Send info to the database and create the place", Toast.LENGTH_SHORT)
//                    .show();

            if (getToastLocation() != null) {
                Toast.makeText(
                        getBaseContext(),
                        "Location added !!! \nLat: " + getToastLocation().getLatitude()
                                + "\nLong: " + getToastLocation().getLongitude(),
                        Toast.LENGTH_SHORT).show();
            } else {
                Toast.makeText(
                        getBaseContext(),
                        "No Location !!!!!",
                        Toast.LENGTH_SHORT).show();
            }

//            Toast.makeText(
//                    getBaseContext(),
//                    "Location changed: \nLat: " + finalLocation.getLatitude()
//                            + "\nLong: " + finalLocation.getLongitude(),
//                    Toast.LENGTH_SHORT).show();

            //Create place

            title = (EditText) this.findViewById(R.id.title_input);
            description = (EditText) findViewById(R.id.description_input);

            if (title.getText().toString().length() >= 3 &&
                    description.getText().toString().length() >= 3) {

                if (pictureName.length() > 5) {
                    Intent intent = new Intent(AddPlaceActivity.this, AddToDatabaseActivity.class);
                    this.startActivity(intent);
                } else {
                    Toast.makeText(context, "You must add picture",
                            Toast.LENGTH_SHORT).show();
                }
            } else {
                Toast.makeText(context, "Invalid Title or Description. The must be at least 3 chars long",
                        Toast.LENGTH_SHORT).show();
            }

        }
    }
}
