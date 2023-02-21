package br.teste;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

public class SecondActivity extends AppCompatActivity {

    ImageView mainImageView;
    TextView title, description;

    String data1, data2;
    int myImageView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second);
        getSupportActionBar().hide();
        mainImageView = findViewById(R.id.mainImageView);
        title = findViewById(R.id.title);
        description = findViewById(R.id.description);
        getData();
        setData();
    }
    private  void getData(){
        if(getIntent().hasExtra("myImageView") && getIntent().hasExtra("data1") && getIntent().hasExtra("data2")){
            data1 = getIntent().getStringExtra("data1");
            data2 = getIntent().getStringExtra("data2");
            myImageView = getIntent().getIntExtra("myImageView", 1);

        }
        else{
            Toast.makeText(this, "Não há dados.",Toast.LENGTH_SHORT).show();

        }
    }
    private void setData(){
        title.setText(data1);
        description.setText(data2);
        mainImageView.setImageResource(myImageView);

    }
}

