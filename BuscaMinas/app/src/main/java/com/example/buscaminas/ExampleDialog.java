package com.example.buscaminas;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatDialogFragment;

public class ExampleDialog extends AppCompatDialogFragment {

    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {

        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setTitle("Instrucciones");
        builder.setMessage("Tu objetivo es despejar un campo de minas real, puedes entrenar en el campo de principiantes," +
                "pulsa casilla al azar para tantear el mapa, si Pisas una mina has muerto, tu objetivo es marcarlas todas, si marcas una casilla" +
                "que no tenga mina pierdes pues das falsa imformacion ." +
                " Buena suerte - Mayor Willis");

        builder.setPositiveButton("entendido", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
            }
        });

        return builder.create();

    }
}
