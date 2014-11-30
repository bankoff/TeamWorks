package com.example.tripadvisor;

import android.app.Activity;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import database.Place;
import database.PlaceDataSource;


public class SinglePictureActivity extends Activity {

    public static Place singlePlaceToDisplay;
    public static final String PICTURE_INDEX = "PictureIndex";
    private static final int INVALID_INDEX = -1;
    private ImageView iv;
    private TextView title, description, distance;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_single_picture);

        loadSelectedPicture(getIntent().getIntExtra(PICTURE_INDEX, INVALID_INDEX));

        title = (TextView) findViewById(R.id.single_title);
        description = (TextView) findViewById(R.id.single_desctiption);
        SetValues();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.single_picture, menu);
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

    public void SetValues() {

        if (AddToDatabaseActivity.allPlacesFromTheBase.size() == 0) {
            //     AddToDatabaseActivity.allPlacesFromTheBase = AddToDatabaseActivity.datasource.getAllPlaces();

            Toast.makeText(getBaseContext(), "Please, create a place first.", Toast.LENGTH_SHORT)
                    .show();
        } else {
            //   Toast.makeText(getBaseContext(), "Selected" + GalleryActivity.positionSelected, Toast.LENGTH_SHORT)
            // .show();
            Integer count = AddToDatabaseActivity.allPlacesFromTheBase.size();

            if (count > GalleryActivity.positionSelected) {
                // Toast.makeText(getBaseContext(), "Count " + count, Toast.LENGTH_SHORT)
                // .show();

                singlePlaceToDisplay = AddToDatabaseActivity.allPlacesFromTheBase
                        .get(GalleryActivity.positionSelected);
                //   Toast.makeText(getBaseContext(), singlePlaceToDisplay.getTitle(), Toast.LENGTH_SHORT)
                //           .show();
                title.setText(singlePlaceToDisplay.getTitle());
                description.setText(singlePlaceToDisplay.getDescription());
            } else {
                Toast.makeText(getBaseContext(), "We have a little problem here," +
                        " please select from the first photos.", Toast.LENGTH_SHORT)
                        .show();
            }
        }
    }

    public void loadSelectedPicture(int pictureIndex) {
        iv = (ImageView) findViewById(R.id.single_image);
        if (pictureIndex != INVALID_INDEX) {
            Bitmap currentPic = HomeActivity.allImages.get(pictureIndex + 2);
            iv.setImageBitmap(currentPic);
        } else {
            Toast.makeText(getBaseContext(), "Something is wrong", Toast.LENGTH_SHORT)
                    .show();
        }

    }
}
