package com.lloppy.magicial.services;

import com.lloppy.magicial.model.Magician;

import java.util.List;
import java.util.stream.Collectors;

public class AbstractMagicianService extends MagicianServise{

    protected List<Magician> magicians;

    @Override
    protected List<Magician> getMagicians(){
        return magicians;
    }

    @Override
    protected Magician getMagicanById(Long id){
        List<Magician> found =
                magicians.stream().filter(magician -> magician.getId() == id).collect(Collectors.toList());
        return found.size() ==
    }
}
