package com.example.buscaminas;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

public class ExampleAdapter extends RecyclerView.Adapter<ExampleAdapter.ExampleViewHolder> {

    private ArrayList<ExampleItem> mExampleList;
    private OnItemClickListener mListener;
    private OnItemLongClickListener mListener2;

    public interface OnItemClickListener{
        void OnItemClick(int position);
    }

    public interface OnItemLongClickListener {
        boolean onItemLongClicked(int position);
    }



    public void setOnClickListener(OnItemClickListener listener){
        mListener=listener;
    }

    public void setOnLongClickListener(OnItemLongClickListener listener){mListener2=listener; }




    public ExampleAdapter() {}

    public void setExampleList(ArrayList<ExampleItem> exampleList){
        mExampleList=exampleList;
    }

    public int getsizeexampleList(){return mExampleList.size();}

    @NonNull
    @Override
    public ExampleViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v= LayoutInflater.from(parent.getContext()).inflate(R.layout.layout_listitem,parent,false);
        ExampleViewHolder exampleViewHolder=new ExampleViewHolder(v,mListener,mListener2);

        return exampleViewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull ExampleViewHolder holder, int position) {
        ExampleItem currentItem=mExampleList.get(position);

        holder.mImageView.setImageResource(currentItem.getImageResource());



    }

    @Override
    public int getItemCount() {

        return mExampleList.size();
    }

    public static class ExampleViewHolder extends RecyclerView.ViewHolder{

        ImageView mImageView;

        public ExampleViewHolder(View itemView, final OnItemClickListener listener , final OnItemLongClickListener listener2){
            super(itemView);
            mImageView=itemView.findViewById(R.id.imageView);

            itemView.setOnClickListener(new View.OnClickListener() {
                //Aqui se establece el metodo onclik
                @Override
                public void onClick(View v) {
                    if (listener!=null){
                        int position=getAdapterPosition();
                        if (position != RecyclerView.NO_POSITION){
                            listener.OnItemClick(position);
                        }
                    }
                }
            });

            //Aqui se establece el metodo onlongclik
            itemView.setOnLongClickListener(new View.OnLongClickListener() {
                @Override
                public boolean onLongClick(View view) {
                    if (listener2!=null){
                        int position=getAdapterPosition();
                        if (position != RecyclerView.NO_POSITION){
                            listener2.onItemLongClicked(position);
                        }
                    }

                    return false;
                }
            });



        }







    }
}
