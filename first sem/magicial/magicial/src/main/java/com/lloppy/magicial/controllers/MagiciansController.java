package com.lloppy.magicial.controllers;

import com.lloppy.magicial.model.Magician;
import com.lloppy.magicial.services.MagicianServise;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.List;

@Controller
public class MagiciansController {
   private final MagicianServise magicianServise;

   @Inject
   public MagiciansController(MagicianServise magicianServise)
   {
      this.magicianServise;
   }

   @GetMapping(value = "/magicians")
   @RequestBody
   public List<Magician> getMagicians()
}
