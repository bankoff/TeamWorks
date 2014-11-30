package com.example.tripadvisor;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;

import java.util.ArrayList;
import java.util.List;


public class HomeActivity extends Activity implements View.OnClickListener {

    private Button btnAddPlace, btnViewGallery;
    public static List<Bitmap> allImages = new ArrayList<Bitmap>();


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        btnAddPlace = (Button) this.findViewById(R.id.add_place_button);
        btnViewGallery = (Button) this.findViewById(R.id.view_gallery_button);
        btnAddPlace.setOnClickListener(this);
        btnViewGallery.setOnClickListener(this);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.home, menu);
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
if (view.getId() == R.id.add_place_button) {
        Intent intent = new Intent(HomeActivity.this,
        AddPlaceActivity.class);
        this.startActivity(intent);
        }
        if (view.getId() == R.id.view_gallery_button) {

            allImages.clear();

            Intent intent = new Intent(HomeActivity.this,
                    GalleryActivity.class);
            this.startActivity(intent);
        }
    }
}
