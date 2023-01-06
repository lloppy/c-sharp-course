package com.lloppy.magicial.services;

import com.lloppy.magicial.model.BabaYaga;
import com.lloppy.magicial.model.Kochey;
import com.lloppy.magicial.model.Magician;

import java.util.ArrayList;
import java.util.List;

public class RussianFaryTaleMagiciansService extends AbstractMagicianService{

    public RussianFaryTaleMagiciansService(){
        magicians = new ArrayList<>();
        magicians.add(new BabaYaga());
        magicians.add(new Kochey());
    }
}
