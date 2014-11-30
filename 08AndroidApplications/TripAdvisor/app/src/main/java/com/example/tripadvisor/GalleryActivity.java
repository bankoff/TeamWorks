package com.example.tripadvisor;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.GridView;
import android.widget.Toast;

import com.telerik.everlive.sdk.core.EverliveApp;
import com.telerik.everlive.sdk.core.model.system.File;
import com.telerik.everlive.sdk.core.result.RequestResult;

import java.util.ArrayList;

public class GalleryActivity extends Activity {
    public EverliveApp app = new EverliveApp("iEFw0m2S2kX61YKR");
    private ImageAdapter imageAdapter;
    private GridView gallery;
    RequestResult<ArrayList<File>> requestResult;
    ArrayList<File> allFiles;
    public static  Integer positionSelected  = -1;

    private void gotoSingleView(int pictureIndex) {
        Intent intent = new Intent(GalleryActivity.this,
                SinglePictureActivity.class);

        intent.putExtra(SinglePictureActivity.PICTURE_INDEX, pictureIndex);
        this.startActivity(intent);
    }

    public class UidAsyncDownloader extends AsyncTask<Void, Void, Void>{
        ArrayList<String> imgUrls = new ArrayList<String>();

        @Override
        protected Void doInBackground(Void... params) {
            requestResult = app.workWith().data(File.class)
                    .getAll().executeSync();

            if (requestResult.getSuccess()) {
                allFiles = requestResult.getValue();

                for (int i = 0; i < allFiles.size(); i++) {
                    String currentUuid = allFiles.get(i).getId().toString();
                    imgUrls.add(currentUuid);
                }
            } else {
                Log.i("ERROR", "BAD THING HAPPENED");
            }
            return null;
        }

        @Override
        protected void onPostExecute(Void v) {
            imageAdapter = new ImageAdapter(GalleryActivity.this, imgUrls);
            gallery.setAdapter(imageAdapter);
            gallery.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                public void onItemClick(AdapterView parent, View v, int position, long id) {


                  positionSelected=position;
                    gotoSingleView(position);

                    Toast.makeText(GalleryActivity.this, "" + position,
                            Toast.LENGTH_SHORT).show();
                }


            });
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_gallery);
        gallery = (GridView) findViewById(R.id.grid_gallery);
        new UidAsyncDownloader().execute();
    }

}