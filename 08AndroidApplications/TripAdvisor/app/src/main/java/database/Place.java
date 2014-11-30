package database;

public class Place {
    private long id;
    private String title;
    private String description;
    private String longitude;
    private String latitude;
    private String picture;


//    public Place(String titleC, String descriptionC, String distanceC, String pictureC) {
//        this.title = titleC;
//        this.description = descriptionC;
//        this.distance = distanceC;
//        this.picture = pictureC;
//    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
           this.id = id;
       }

//    // Will be used by the ArrayAdapter in the ListView
//    @Override
//    public String toString() {
//        return comment;
//    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getDescription() {
        return description;
    }

    public String getPicture() {
        return picture;
    }

    public void setPicture(String picture) {
        this.picture = picture;
    }

    public String getLongitude() {
        return longitude;
    }

    public void setLongitude(String longitude) {
        this.longitude = longitude;
    }

    public String getLatitude() {
        return latitude;
    }

    public void setLatitude(String latitude) {
        this.latitude = latitude;
    }


}