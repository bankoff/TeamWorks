package com.example.tripadvisor;

import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.ImageView;

import com.telerik.everlive.sdk.core.EverliveApp;
import com.telerik.everlive.sdk.core.model.system.DownloadedFile;
import com.telerik.everlive.sdk.core.result.RequestResult;

import java.lang.ref.WeakReference;
import java.util.List;
import java.util.UUID;

public class ImageAdapter extends BaseAdapter {

    public EverliveApp app = new EverliveApp("iEFw0m2S2kX61YKR");
    private ImageView iv;
  public  static   List<String> images;
    private Context context;

    public ImageAdapter(Context applicationContext, List<String> imgUrls) {
        context = applicationContext;
        this.images = imgUrls;
    }

    @Override
    public int getCount() {
        return images.size();
    }

    @Override
    public Object getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if (convertView != null) {
            iv = (ImageView) convertView;
        } else {
            iv = new ImageView(context);
            iv.setLayoutParams(new GridView.LayoutParams(150, 100));
            iv.setScaleType(ImageView.ScaleType.CENTER_INSIDE);
            iv.setPadding(5, 5, 5, 5);
        }

        new PictureAsyncDownloader(iv).execute(images.get(position));

        return iv;
    }
// parceable extends bitmap

}