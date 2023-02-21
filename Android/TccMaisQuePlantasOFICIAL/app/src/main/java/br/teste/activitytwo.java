package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

public class activitytwo extends AppCompatActivity {

    ImageView mainImageView2;
    TextView title2, description2;

    String data3, data4;
    int myImageView2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_activitytwo);
        getSupportActionBar().hide();
        mainImageView2 = findViewById(R.id.mainImageView2);
        title2 = findViewById(R.id.title2);
        description2 = findViewById(R.id.description2);
        getData();
        setData();
    }
    private  void getData(){
        if(getIntent().hasExtra("myImageView2") && getIntent().hasExtra("data3") && getIntent().hasExtra("data4")){
            data3 = getIntent().getStringExtra("data3");
            data4 = getIntent().getStringExtra("data4");
            myImageView2 = getIntent().getIntExtra("myImageView2", 1);

        }
        else{
            Toast.makeText(this, "Não há dados.",Toast.LENGTH_SHORT).show();

        }
    }
    private void setData(){
        title2.setText(data3);
        description2.setText(data4);
        mainImageView2.setImageResource(myImageView2);

    }
}
