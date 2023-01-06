package com.lloppy.magicial.services;

import com.lloppy.magicial.model.*;

import java.util.ArrayList;
import java.util.List;

public class HarryPotterMagicianSetvise extends AbstractMagicianService{

    public HarryPotterMagicianSetvise(){
        magicians = new ArrayList<>();
        magicians.add(new HarryPotter());
        magicians.add(new HermioneGrange());
        magicians.add(new RonadlWeathley());
    }
}
