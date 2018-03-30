package Comunicacion;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.net.ServerSocket;
import java.net.Socket;

public class Servidor {
    final int PUERTO=6750;
    ServerSocket sc;
    Socket so;
    DataOutputStream salida;
    //String msj_in;
    BufferedReader entrada;
    
    public boolean conectar(){
        try{
            sc = new ServerSocket(PUERTO);
            so = new Socket();
            System.out.println("Esperando conexión");
            so=sc.accept();
            return true;
        }catch(Exception e){
            System.out.println("Error:"+e.toString());
        }
        return false;
    }
    
    public String recibir(){
        if(so==null){
            return "ER";//error
        }
        try{
            if(entrada==null){
                entrada = new BufferedReader(new InputStreamReader(so.getInputStream()));
            }
            return entrada.readLine();
        }catch (Exception e){
            return "ER";//error
        }
    }
    
    public boolean enviar(String mensaje){
        if(so==null){
            return false;
        }
        try{
            if(salida==null){
                salida = new DataOutputStream(so.getOutputStream());
            }
            salida.writeUTF(mensaje);
            return true;
        }catch (Exception e){
            return false;
        }
    }
    
    public void cerrar(){
        try{
            if(sc!=null){
                sc.close();
            }
        }catch (Exception e){
            System.out.println("Error"+e.toString());
        }
        
    }
}
