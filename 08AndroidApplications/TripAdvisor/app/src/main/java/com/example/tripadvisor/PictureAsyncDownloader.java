package com.example.tripadvisor;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.widget.ImageView;

import com.example.tripadvisor.R;
import com.telerik.everlive.sdk.core.EverliveApp;
import com.telerik.everlive.sdk.core.model.system.DownloadedFile;
import com.telerik.everlive.sdk.core.result.RequestResult;

import java.lang.ref.WeakReference;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;


public class PictureAsyncDownloader extends AsyncTask<String, Integer, Bitmap> {

    public EverliveApp app = new EverliveApp("iEFw0m2S2kX61YKR");
    private final WeakReference imageViewReference;


    public PictureAsyncDownloader(ImageView imageView) {
        imageViewReference = new WeakReference(imageView);
    }

    @Override
    protected Bitmap doInBackground(String... params) {
        // TODO Auto-generated method stub
        UUID uid = UUID.fromString(params[0]);

        Bitmap tempImage;
        RequestResult result = app.workWith().files().download(uid)
                .executeSync();

//            if (result.getSuccess()) {

        DownloadedFile file = (DownloadedFile) result.getValue();
        tempImage = BitmapFactory.decodeStream(file.getInputStream());
//            }
//            else{
//                tempImage = BitmapFactory.decodeResource(getResources(),R.drawable.error);
//            }
       HomeActivity.allImages.add(tempImage);

        return tempImage;
    }


    @Override
    protected void onPostExecute(Bitmap img) {
        // progressDialog.dismiss();
        if (isCancelled()) {
            img = null;
        }
        if (imageViewReference != null) {
            ImageView imageView = (ImageView) imageViewReference.get();
            if (imageView != null) {
                if (img != null) {
                    imageView.setImageBitmap(img);
                } else {
                    imageView.setImageDrawable(imageView.getContext()
                            .getResources()
                            .getDrawable(R.drawable.ic_launcher));
                }
            }
        }
    }

}