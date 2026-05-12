<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\Turak;
use App\Models\Kategoriak;
use Illuminate\Support\Facades\Validator;

class TurakController extends Controller
{
    public function show($id)
    {
        $turak = Turak::where('kategoria_id', $id)->get();
        return response()->json($turak, 200);
    }


    public function store(Request $request)
    {
    $required = ['kategoria_id', 'leiras', 'indulas', 'tav', 'aktiv', 'kep'];

    foreach ($required as $field) {
        if (!$request->has($field)) {
            return response()->json("Hiányos adatok.", 400);
        }
    }

    $tura = Turak::create([
        'kategoria_id' => $request->input('kategoria_id'),
        'leiras'       => $request->input('leiras'),
        'indulas'      => $request->input('indulas'),
        'tav'          => $request->input('tav'),
        'aktiv'        => $request->input('aktiv'),
        'kep'          => $request->input('kep'),
    ]);

    return response()->json(['id' => $tura->id], 201);
    }

    public function update(Request $request, $id)
    {
    $tura = Turak::find($id);

    if (!$tura) {
        return response()->json("A túra nem létezik.", 404);
    }

    $data = $request->only(['kategoria_id', 'leiras', 'indulas', 'tav', 'aktiv', 'kep']);

    $tura->fill($data);
    $tura->save();

    return response()->json($tura, 200);
    }

    
}