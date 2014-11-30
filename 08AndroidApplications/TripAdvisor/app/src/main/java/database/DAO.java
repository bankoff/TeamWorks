//package database;
//
//import android.app.ListActivity;
//import android.os.Bundle;
//import android.view.View;
//import android.widget.ArrayAdapter;
//
//
//import com.example.tripadvisor.R;
//
//import java.util.List;
//import java.util.Random;
//
//
//public class DAO extends ListActivity {
//
//    private PlaceDataSource datasource;
//
//    @Override
//    protected void onCreate(Bundle savedInstanceState) {
//        super.onCreate(savedInstanceState);
//        setContentView(R.layout.activity_gallery);
//
//        datasource = new PlaceDataSource(this);
//        datasource.open();
//
//        List<Place> values = datasource.getAllPlaces();
//
//        // use the SimpleCursorAdapter to show the
//        // elements in a ListView
//        ArrayAdapter<Place> adapter = new ArrayAdapter<Place>(this,
//                android.R.layout.simple_list_item_1, values);
//        setListAdapter(adapter);
//    }
//
//    // Will be called via the onClick attribute
//    // of the buttons in main.xml
//    public void onClick(View view) {
//        @SuppressWarnings("unchecked")
//        ArrayAdapter<Place> adapter = (ArrayAdapter<Place>) getListAdapter();
//        Place place = null;
//        switch (view.getId()) {
//            case R.id.buttonShow:
//                String[] comments = new String[] { "Cool", "Very nice", "Hate it" };
//                int nextInt = new Random().nextInt(3);
//                // save the new comment to the database
//                comment = datasource.createComment(comments[nextInt]);
//                adapter.add(comment);
//                break;
////            case R.id.delete:
////                if (getListAdapter().getCount() > 0) {
////                    comment = (Comment) getListAdapter().getItem(0);
////                    datasource.deleteComment(comment);
////                    adapter.remove(comment);
////                }
////                break;
//        }
//        adapter.notifyDataSetChanged();
//    }
//
//    @Override
//    protected void onResume() {
//        datasource.open();
//        super.onResume();
//    }
//
//    @Override
//    protected void onPause() {
//        datasource.close();
//        super.onPause();
//    }
//}