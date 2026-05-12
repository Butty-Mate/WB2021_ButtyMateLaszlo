<?php

namespace App\Http\Controllers;

use App\Models\ingatlanok;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class IngatlanokController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $ingatlan = ingatlanok::with('kategoria')->get();
        return response()->json($ingatlan, 200);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $required = ['kategoria', 'leiras', 'tehermentes', 'ar', 'kepUrl'];

        foreach ($required as $field) {
            if (!$request->has($field)) {
                return response()->json("Hiányos adatok.", 400);
            }
        }

        $ingatlan = ingatlanok::create([
            'kategoria' => $request->input('kategoria'),
            'leiras'       => $request->input('leiras'),
            'hirdetesDatuma' => $request->input('hirdetesDatuma'),
            'tehermentes'  => $request->input('tehermentes'),
            'ar'      => $request->input('ar'),
            'kepUrl'     => $request->input('kepUrl'),
        ]);

        return response()->json(['id' => $ingatlan->id], 201);
}

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, $id)
    {
        $validator = Validator::make($request->all(), [
            'kategoria' => 'required',
            'tehermentes' => 'required',
            'ar' => 'required',
        ]);

        if ($validator->fails()) {
            return response()->json("Hiányos adatok.", 400);
        }

        $ingatlan = ingatlanok::find($id);

        if (!$ingatlan) {
            return response()->json("Az ingatlan nem létezik.", 404);
        }

        $ingatlan->update($request->all());
        return response()->json($ingatlan, 200);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy($id)
    {
        $ingatlan = ingatlanok::find($id);

        if (!$ingatlan) {
            return response()->json("Az ingatlan nem létezik.", 404);
        }

        $ingatlan->delete();
        return response()->json('', 204);
    }
}
